using DotNetTodoAPI.Model;
using System.Collections.Generic;

namespace DotNetTodoAPI.Repo
{
    public interface IAttachment
    {
        IEnumerable<Attachment> GetAll();
        Attachment GetById(int id);
        void Add(Attachment attachment);
        void Update(Attachment attachment);
        void Delete(int id);
    }
}
