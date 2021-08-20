using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

#nullable disable

namespace fromProduct.Models.DB
{
    public partial class ProductsTbl
    {
        [Display(Name = "ลำดับเมนูอาหาร")]
        [Required(ErrorMessage = "ดูลำดับเมนูอาหารได้โดยกดที่ fromProduct (ห้ามใส่ลำดับเมนูซ้ำกัน)")]
        public int ProductId { get; set; }

        [Display(Name = "ชื่อเมนูอาหาร")]
        [Required(ErrorMessage = "กรุณาใส่ชื่อเมนู")]
        public string ProductName { get; set; }

        [Display(Name = "ราคาอาหาร")]
        [Required(ErrorMessage = "กรุณาใส่ราคา")]
        public decimal? ProductPrice { get; set; }

        [Display(Name = "ประเภทอาหาร (อาหารจานเดียวคืออาหารตามสั่งทั้งหมด นอกจากนั้นเป็นกับข้าว)")]
        [Required(ErrorMessage = "เลือกประเภทอาหาร")]
        public int? CategoryId { get; set; }
        
        public virtual CategoriesTbl Category { get; set; }
    }
}
