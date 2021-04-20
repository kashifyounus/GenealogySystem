using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeSystem
{
    public class BaseEntityVM 
    {
        public int Id { get; set; }
    }

    public class PersonVM
    {
        public int Id { get; set; }
        public string FullName { get 
            {
                return FirstName + " " + LastName;
            } 
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Profession { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Reference { get; set; }

        public int ParentId { get; set; }
        public List<SelectListItem> Parents { get; set; }
    }
    public class FamilyTreeVM : BaseEntityVM
    {
        public int PersonId { get; set; }
        public virtual PersonVM Person { get; set; }
        public int FatherId { get; set; }
        public int MotherId { get; set; }
        public Nullable<int> MartialRelationId { get; set; }
        public virtual PersonVM Father { get; set; }
        public virtual PersonVM Mother { get; set; }
        public virtual List<SiblingRelationVM> Siblings { get; set; }


    }
    public class SiblingRelationVM : BaseEntityVM
    {
        public int PersonId { get; set; }
        public virtual PersonVM Person { get; set; }
        public int SiblingId { get; set; }
        public virtual PersonVM Sibling { get; set; }
    }
    public class MartialRelationVM : BaseEntityVM
    {
        public int PersonId { get; set; }
        public virtual PersonVM Person { get; set; }
        public int PartnerId { get; set; }
        public virtual PersonVM Partner { get; set; }
        public Nullable<DateTime> MarriedDate { get; set; }

        public virtual List<ChildrenVM> Childrens { get; set; }
    }
    public class ChildrenVM : BaseEntityVM
    {
        public int MartialRelationId { get; set; }
        public virtual MartialRelationVM Parents { get; set; }
        public int ChildId { get; set; }
        public virtual PersonVM Child { get; set; }
        public int ChildNo { get; set; }
    }
}
