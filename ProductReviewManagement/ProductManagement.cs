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

    }
}
