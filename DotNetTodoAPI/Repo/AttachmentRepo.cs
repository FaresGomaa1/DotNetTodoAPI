using System;
using System.Collections.Generic;
using System.Linq;
using DotNetTodoAPI.Database;
using DotNetTodoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoAPI.Repo
{
    public class AttachmentRepo : IAttachment
    {
        private readonly TodoContext _context;

        public AttachmentRepo(TodoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Attachment> GetAll()
        {
            return _context.Attachments.ToList();
        }

        public Attachment GetById(int id)
        {
            return _context.Attachments.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Attachment attachment)
        {
            if (attachment == null)
            {
                throw new ArgumentNullException(nameof(attachment));
            }

            _context.Attachments.Add(attachment);
            _context.SaveChanges();
        }

        public void Update(Attachment attachment)
        {
            var existingAttachment = GetById(attachment.Id);
            if (existingAttachment == null)
            {
                throw new InvalidOperationException("Attachment not found");
            }

            existingAttachment.FilePath = attachment.FilePath;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var attachmentToRemove = GetById(id);
            if (attachmentToRemove != null)
            {
                _context.Attachments.Remove(attachmentToRemove);
                _context.SaveChanges();
            }
        }
    }
}