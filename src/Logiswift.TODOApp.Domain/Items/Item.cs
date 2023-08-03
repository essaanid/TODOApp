
using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Logiswift.TODOApp.Items
{
    public class Item : FullAuditedAggregateRoot<Guid>
    {
        public string Subject { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public Guid UserId { get; set; }

        private Item()
        {
            CreationTime= DateTime.Now;
            IsDeleted= false;
            IsDone = false;
        }

        internal Item(
            Guid id,
            [NotNull] string subject,
            [NotNull] Guid userId)
            : base(id)
        {
            SetSubject(subject);
            UserId= userId;
            CreationTime = DateTime.Now;
            IsDone = false;
        }

        internal Item ChangeSubject([NotNull] string subject)
        {
            SetSubject(subject);
            return this;
        }

        private void SetSubject([NotNull] string subject)
        {
            Subject = Check.NotNullOrWhiteSpace(
                subject,
                nameof(subject),
                maxLength: ItemConsts.MaxSubjectLength
            );
        }

        internal Item SetAsDone()
        {
            SetStatus(true);
            FinishDate= DateTime.Now;
            return this;
        }
        private void SetStatus([NotNull] bool status)
        {
            IsDone = status;
        }
    }
}