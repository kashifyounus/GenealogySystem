using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeSystem.Models
{
    public class Person : BaseEntity
    {
        public string FullName { get { return FirstName + " " + LastName; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Profession { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Reference { get; set; }
        
    }
    public class FamilyTree : BaseEntity
    {
        public int FamilyUniqueNo { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int ParentId { get; set; }
        public virtual Parent Parents { get; set; }
        public virtual ICollection<MartialRelation>  MartialRelation { get; set; }
        public virtual ICollection<SiblingRelation> Siblings { get; set; }
        public virtual ICollection<Children> Childrens { get; set; }
    }
    public class Parent : BaseEntity
    {
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        public int FatherId { get; set; }
        public int MotherId { get; set; }
        [ForeignKey("FatherId")]
        public virtual Person Father { get; set; }
        [ForeignKey("MotherId")]
        public virtual Person Mother { get; set; }
    }
    public class SiblingRelation : BaseEntity
    {
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person  { get; set; }
        public int SiblingId { get; set; }

        [ForeignKey("SiblingId")]
        public virtual Person Sibling { get; set; }
    }
    public class MartialRelation : BaseEntity
    {
        public string CoupleName { get 
            {
              return Husband?.FullName + "<--->"+ Wife?.FullName;
            }
        }
        public int HusbandId { get; set; }
        [ForeignKey("HusbandId")]
        public virtual Person Husband { get; set; }
        public int WifeId { get; set; }
        [ForeignKey("WifeId")]
        public virtual Person Wife { get; set; }
        public Nullable<DateTime> MarriedDate { get; set; }        
    }
    public class Children : BaseEntity
    {
        public int MartialRelationId { get; set; }
        [ForeignKey("MartialRelationId")]
        public virtual MartialRelation Parents { get; set; }
        public int ChildId { get; set; }
        [ForeignKey("ChildId")]
        public virtual Person Child { get; set; }
        public int ChildNo { get; set; }
    }

    //()

}
