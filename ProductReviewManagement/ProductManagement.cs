using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;


namespace ProductReviewManagement
{
    class ProductManagement
    {
        public readonly DataTable dataTable = new DataTable();
        /// <summary>
        /// selected records with order by clause. UC2
        /// </summary>
        /// <param name="review">The review.</param>
        public void TopRecords(List<ProductReview> listReview)
        {
            //using query syntax
            var recordedData = (from productReviews in listReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            //using lambda syntax
            var recordData = listReview.OrderByDescending(r => r.Rating).Take(3);
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }
        }
        /// <summary>
        /// Selected records with where condition UC3
        /// </summary>
        /// <param name="listReview">The list review.</param>
        public void SelectedRecords(List<ProductReview> listReview)
        {
            //lambda syntax
            var recordData = listReview.Where(r => r.Rating > 3 && (r.ProductId == 1 || r.ProductId == 4 || r.ProductId == 9)).ToList();
            //query syntax
            var recordedData = (from productReviews in listReview
                                where productReviews.Rating > 3 && (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9)
                                select productReviews);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }
        }
        /// <summary>
        /// Counts the of reviews grouping by user id UC4
        /// </summary>
        /// <param name="listProductReview">The list product review.</param>
        public void countOfReviews(List<ProductReview> listProductReview)
        {
            //lambda syntax
            var recordData = listProductReview.GroupBy(r => r.UserId).Select(r => new { productId = r.Key, count = r.Count() });
            //query syntax
            var recordedData = from products in listProductReview
                               group products by products.UserId into g
                               select new
                               {
                                   userId = g.Key,
                                   count = g.Count()
                               };

            foreach (var list in recordedData)
            {
                Console.WriteLine("UserId:-" + list.userId + " Count:-" + list.count);
            }
        }

    }
}
