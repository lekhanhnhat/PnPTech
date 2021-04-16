namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int CategoryID { get; set; }

        [StringLength(100,ErrorMessage ="So ky tu toi da la 100")]
        [DisplayName("Ten danh muc")]
        [Required(ErrorMessage ="Ban chua nhap ten danh muc")]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [DisplayName("Danh muc cha")]
        public int? ParentID { get; set; }

        [DisplayName("Thu tu")]
        [Range(0,Int32.MaxValue,ErrorMessage ="Ban phai nhap so")]
        public int? DisplayOrder { get; set; }

        [StringLength(250,ErrorMessage ="Khong qua 250 ky tu")]
        [DisplayName("Tieu de SEO")]
        public string SeoTitle { get; set; }

        [DisplayName("Ngay tao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }
        [DisplayName("Trang thai")]
        public bool Status { get; set; }

        public bool ShowOnHome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
