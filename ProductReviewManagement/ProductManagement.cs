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
    }
}
