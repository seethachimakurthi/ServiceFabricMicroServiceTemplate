using AutoMapper;

namespace Renting.Master.Core
{
    public class MappingConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config => config.AddProfile(new MappingProfile()));
        }
    }
}
