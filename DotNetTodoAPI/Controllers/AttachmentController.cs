using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DotNetTodoAPI.DTOs;
using DotNetTodoAPI.Model;
using DotNetTodoAPI.Repo;

namespace DotNetTodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachment _attachmentRepo;
        private readonly ITodo _TodoRepo;

        public AttachmentController(IAttachment attachmentRepo, ITodo TodoRepo)
        {
            _attachmentRepo = attachmentRepo ?? throw new ArgumentNullException(nameof(attachmentRepo));
            _TodoRepo = TodoRepo ?? throw new ArgumentNullException(nameof(TodoRepo));
        }

        [HttpGet]
        public IActionResult GetAllAttachments()
        {
            var attachments = _attachmentRepo.GetAll();
            var attachmentDTOs = new List<AttachmentDTOGet>();

            foreach (var attachment in attachments)
            {
                attachmentDTOs.Add(new AttachmentDTOGet
                {
                    Id = attachment.Id,
                    FilePath = attachment.FilePath,
                    TodoId = attachment.TodoId,
                });
            }

            return Ok(attachmentDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetAttachmentById(int id)
        {
            var attachment = _attachmentRepo.GetById(id);

            if (attachment == null)
            {
                return NotFound();
            }

            var attachmentDTO = new AttachmentDTOGet
            {
                Id = attachment.Id,
                FilePath = attachment.FilePath,
                TodoId = attachment.TodoId,
            };

            return Ok(attachmentDTO);
        }

        [HttpPost]
        public IActionResult AddAttachment([FromBody] AttachmentCreateDTO attachmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the provided TodoId exists
            var todo = _TodoRepo.GetById(attachmentDTO.TodoId);
            if (todo == null)
            {
                return BadRequest("The specified TodoId does not exist");
            }

            var attachment = new Attachment
            {
                FilePath = attachmentDTO.FilePath,
                TodoId = attachmentDTO.TodoId
            };

            _attachmentRepo.Add(attachment);

            // Return the created attachment DTO
            var createdAttachmentDTO = new AttachmentCreateDTO
            {
                FilePath = attachment.FilePath,
                TodoId = attachment.TodoId
            };

            return CreatedAtAction(nameof(GetAttachmentById), new { id = attachment.Id }, createdAttachmentDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAttachment(int id, [FromBody] AttachmentCreateDTO attachmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAttachment = _attachmentRepo.GetById(id);

            if (existingAttachment == null)
            {
                return NotFound();
            }

            // Check if the provided TodoId exists
            var todo = _TodoRepo.GetById(attachmentDTO.TodoId);
            if (todo == null)
            {
                return BadRequest("The specified TodoId does not exist");
            }

            existingAttachment.FilePath = attachmentDTO.FilePath;
            existingAttachment.TodoId = attachmentDTO.TodoId;

            _attachmentRepo.Update(existingAttachment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAttachment(int id)
        {
            var existingAttachment = _attachmentRepo.GetById(id);

            if (existingAttachment == null)
            {
                return NotFound();
            }

            _attachmentRepo.Delete(id);

            return NoContent();
        }
    }
}
