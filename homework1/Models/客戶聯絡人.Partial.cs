namespace homework1.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var db = new CustomerEntities();

            if (this.Id == 0)
            {
                var data = db.客戶聯絡人.FirstOrDefault(s => s.客戶Id == this.客戶Id && s.Email == this.Email);
                if (data != null)
                {
                    yield return new ValidationResult("此Email已存在",new string[] {"Email"});
                }
            }
            else
            {
                var data = db.客戶聯絡人.FirstOrDefault(s => s.客戶Id == this.客戶Id && s.Id != this.Id && s.Email == this.Email);
                if(data != null)
                {
                    yield return new ValidationResult("此Email已存在", new string[] { "Email" });
                }
            }
        }
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        [EmailAddress(ErrorMessage = "請輸入正確Email格式")]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [RegularExpression(@"\d{4}-\d{6}", ErrorMessage = "電話格式錯誤( e.g. 0911-111111 )")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
