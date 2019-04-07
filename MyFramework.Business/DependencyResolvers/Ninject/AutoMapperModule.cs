using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ninject.Modules;

namespace MyFramework.Business.DependencyResolvers.Ninject
{
    //ninjecte dahil etmemız gerekir
    //Automappermodulu wvc in gloabal assaxına eklıyorum,
    //wep apinin app startındakı web common da RegisterServices bolumune ekleme yapıyorum
    //ninject controler factorye ekleme yapıyorum
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(CreateConfiguration().CreateMapper()).InSingletonScope();
        }

        //aynı assembly dekı profil tıpındekı herseyi yukardakı load metoduna eklyecek
        private MapperConfiguration CreateConfiguration()
        {
            var config=new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(GetType().Assembly);
            });

            return config;
        }
    }
}
