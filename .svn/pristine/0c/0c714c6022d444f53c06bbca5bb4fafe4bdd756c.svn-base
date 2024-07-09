//  
// Type: CodeLock.Models.UnityDependencyResolver
//  
//  
//  

using Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class UnityDependencyResolver : IDependencyResolver
  {
    private IUnityContainer unityContainer;

    public UnityDependencyResolver(IUnityContainer _unityContainer)
    {
      this.unityContainer = _unityContainer;
    }

    public object GetService(Type serviceType)
    {
      try
      {
        return this.unityContainer.Resolve(serviceType);
      }
      catch (Exception ex)
      {
        return (object) null;
      }
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      try
      {
        return this.unityContainer.ResolveAll(serviceType);
      }
      catch (Exception ex)
      {
        return (IEnumerable<object>) new List<object>();
      }
    }
  }
}
