namespace DayFive.Model
{
    public class InstructionCode
    {
        public int Opcode { get; set; }
        public ParameterMode FirstParameter { get; set; }
        public ParameterMode SecondParameter { get; set; }
        public ParameterMode ThirdParameter { get; set; }

        public InstructionCode(string codeString)
        {
            codeString = codeString.PadLeft(5, '0');

            Opcode = int.Parse(codeString.Substring(3, 2));
            FirstParameter = (ParameterMode)int.Parse(codeString.Substring(2, 1));
            SecondParameter = (ParameterMode)int.Parse(codeString.Substring(1, 1));
            ThirdParameter = (ParameterMode)int.Parse(codeString.Substring(0, 1));
        }

        public InstructionCode(int code) : this(code.ToString()) { }
    }
}
