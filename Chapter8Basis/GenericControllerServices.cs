using CrudImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Chapter8Basis
{
    public class GenericControllerServices<TEntity>
    {
        public GenericController<TEntity> CreateGenericTEntityServices()
        {
            var reader = new Reader<TEntity>();
            var saver = new Saver<TEntity>();
            var deleter = new Deleter<TEntity>();
            GenericController<TEntity> ctl = (GenericController<TEntity>)Activator.CreateInstance(typeof(GenericController<TEntity>), reader, saver, deleter);
            return ctl;
        }
    }
}
