using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Mappings.AutoMapper.Profiles
{
    //yeni bir profil ekleyecegımzde tek yapmamız gereken BusinessProfile gibi bir profil oluşturmak 
    public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, Product>();
        }
    }
}
