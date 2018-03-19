//using System;
//using DependencyInjectionChp18.Models.InterfaceDi;

//namespace DependencyInjectionChp18.Models
//{
//    public class MemoryFactory : IMemoryFactory
//    {
//        private IServiceProvider provider;
//        private IRepository repo;
//        public MemoryFactory(IServiceProvider provider)
//        {
//            this.provider = provider;
//        }

//        public IRepository Create(string controllerName)
//        {
//            if (String.IsNullOrWhiteSpace(controllerName))
//            {
//                throw new ArgumentException(nameof(controllerName));
//            }


//            switch (controllerName.ToLower())
//            {
//                case "memorycontroller":
//                    repo = this.provider.GetService(typeof(MemoryRepository)) as MemoryRepository;
//                    break;

//                case "alternatememorycontroller":
//                    //repo = provider.GetService(Type.GetType(typeof(AlternateRepository).ToString())) as AlternateRepository;
//                    repo = this.provider.GetService(typeof(DependencyInjectionChp18.Models.AlternateRepository)) as AlternateRepository;
//                    break;
//            }
//            return repo;
//        }


//    }

//    public interface IMemoryFactory
//    {
//        IRepository Create(string controllerName);
//    }
//}
