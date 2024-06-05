using Application.Dto.States;
using Application.Features.Cities.Commands.CreateCities;
using Application.Features.Countries.Commands;
using Application.Features.Countries.Commands.CreateCountries;
using Application.Features.Staffs.Commands.CreateStaffs;
using Application.Features.States.Commmand.CreateStates;
using Application.Features.Students.Commands.CreateStudent;
using Application.Features.Users.Commands.CreateUsers;
using AutoMapper;
using Domain.Entities.Cities;
using Domain.Entities.Countries;
using Domain.Entities.staffs;
using Domain.Entities.States;
using Domain.Entities.Students;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comman.Mappings
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<CreateCountryCommand, Country>();
            CreateMap< CreateCommandCountry,Country > ();
            CreateMap<CreateStateCommand, State>();
            CreateMap<State, GetStateDto>();
            CreateMap<CreateCityCommand, City>();
            CreateMap<CreateuserCommand, User>();
            CreateMap<CreateStudentCommand,Student>();
            CreateMap<CreateStaffCommand,Staff>();
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapfromType = typeof(IMapFrom<>);
            var mappingMethodName=nameof(IMapFrom<object>.Mapping);
            bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapfromType;
            var types=assembly.GetExportedTypes().Where(t=>t.GetInterfaces().Any(HasInterface)).ToList();
            var argumentTypes = new Type[] { typeof(Profile) };
            foreach (var type in types)
            {
                var instance=Activator.CreateInstance(type);
                var methodInfo=type.GetMethod(mappingMethodName);
                if (methodInfo != null)
                {
                    methodInfo.Invoke(instance, new object[] {this});
                }
                else
                {
                    var interfaces=type.GetInterfaces().Where(HasInterface).ToList();

                    if(interfaces.Count>0)
                    {
                        foreach(var @interface in interfaces)
                        {
                            var interfaceMethodInfo=@interface.GetMethod(mappingMethodName,argumentTypes);
                            interfaceMethodInfo.Invoke(instance,new object[] {this});
                        }
                    }
                }
            }
        }
    }
}
