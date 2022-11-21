using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCRUD.Model
{
    public class Part
    {
        public int PartID { get; set; }
        public int FoundDeptID { get; set; }    
        public int SourceDeptID { get; set; }
        public int DefectID { get; set; }
        public int DefectQTY { get; set; }
        public int Reason { get; set; }
        public int CorrectActID { get; set; }
        public string Comments { get; set; }
    }
    public class DefectCategory
    {
        public int DefectID { get; set; }
        public string Category { get; set; }
    }
    public class Reason
    {
        public int ReasonId { get; set; }
        public string ReasonText { get; set; }
    }
    public class DefectQuantity
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
    }
    public class CorrctiveAction
    {
        public int Id { get; set; }
        public string Action { get; set; }
    }
}
