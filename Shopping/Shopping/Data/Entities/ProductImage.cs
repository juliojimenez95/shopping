using System.ComponentModel.DataAnnotations;
using Shopping.Helpers;

namespace Shopping.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: Pending to change to the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? "/images/noimage.png"
            : BlobUrlHelper.GetBlobUrl("products", ImageId);

    }
}
