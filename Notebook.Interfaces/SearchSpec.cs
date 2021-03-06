﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Notebook.Interfaces
{
    public interface ISearchCriteriaVisitor
    {
        void VisitByName(ByNameSearchCriteria sc);
        void VisitBySurname(BySurnameSearchCriteria sc);
        void VisitByPhone(ByPhoneSearchCriteria sc);
        void VisitByEmail(ByEmailSearchCriteria sc);
    }

    [Serializable]
    [DataContract]
    public abstract class SearchCriteria
    {
        [DataMember]
        public string Text { get; private set; }

        public SearchCriteria(string text)
        {
            this.Text = text;
        }

        public void Apply(ISearchCriteriaVisitor visitor)
        {
            this.ApplyImpl(visitor);
        }

        protected abstract void ApplyImpl(ISearchCriteriaVisitor visitor);
    }

    [Serializable]
    [DataContract]
    public class ByNameSearchCriteria : SearchCriteria
    {
        public ByNameSearchCriteria(string text)
            : base(text) { }

        protected override void ApplyImpl(ISearchCriteriaVisitor visitor)
        {
            visitor.VisitByName(this);
        }
    }

    [Serializable]
    [DataContract]
    public class BySurnameSearchCriteria : SearchCriteria
    {
        public BySurnameSearchCriteria(string text)
            : base(text) { }

        protected override void ApplyImpl(ISearchCriteriaVisitor visitor)
        {
            visitor.VisitBySurname(this);
        }
    }

    [Serializable]
    [DataContract]
    public class ByPhoneSearchCriteria : SearchCriteria
    {
        public ByPhoneSearchCriteria(string text)
            : base(text) { }

        protected override void ApplyImpl(ISearchCriteriaVisitor visitor)
        {
            visitor.VisitByPhone(this);
        }
    }

    [Serializable]
    [DataContract]
    public class ByEmailSearchCriteria : SearchCriteria
    {
        public ByEmailSearchCriteria(string text)
            : base(text) { }

        protected override void ApplyImpl(ISearchCriteriaVisitor visitor)
        {
            visitor.VisitByEmail(this);
        }
    }

    [Serializable]
    [DataContract]
    public class SearchSpec
    {
        [DataMember]
        public ReadOnlyCollection<SearchCriteria> Conditions { get; private set; }

        public SearchSpec(params SearchCriteria[] conds)
        {
            this.Conditions = new ReadOnlyCollection<SearchCriteria>(conds);
        }
    }

}
