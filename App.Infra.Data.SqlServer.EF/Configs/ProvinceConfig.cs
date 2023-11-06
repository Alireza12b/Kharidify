using App.Domain.Core.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.SqlServer.EF.Configs
{
    public class ProvinceConfig : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Provinces");

            string provinceName = @"آذربایجان شرقی
آذربایجان غربی
اردبیل
اصفهان
البرز
ایلام
بوشهر
تهران
چهارمحال و بختیاری
خراسان جنوبی
خراسان رضوی
خراسان شمالی
خوزستان
زنجان
سمنان
سیستان و بلوچستان
فارس
قزوین
قم
کردستان
کرمان
کرمانشاه
کهگیلویه و بویراحمد
گلستان
لرستان
گیلان
مازندران
مرکزی
هرمزگان
همدان
یزد
";

            var provinces = new List<Province>();
            foreach (var item in provinceName.Split('\n'))
            {
                provinces.Add(new Province
                {
                    Name = item
                });
            }

            builder.HasData(provinces);
        }
    }
}
