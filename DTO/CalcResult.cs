using System.Collections.Generic;

namespace Isracard.DTO
{
    public class CalcResult
    {
        public int Result { get; set; }
        public List<DTO.CalcItem> History { get; set; }
    }
}