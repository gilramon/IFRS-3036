using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    internal class CommandClass
    {

        public enum ArgumentType
        {
            String,
            integer,
            HexString,
            int16, // 
        }
        
        public String Command_name = "";
        public String Help = "";
        public String Example = "";
     //   public ArgumentType[] Arguments;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_CommandName"></param>
        /// <param name="i_CommandHelp"></param>
        public CommandClass(String i_CommandName, String i_CommandHelp)
        {
            Command_name = i_CommandName;
            Help = i_CommandHelp;
        }

        String CheckCommandValidity(String i_Command)
        {
            String ret = "";
            String[] tempStr = i_Command.Split(' ');

            //if(tempStr.Length-1 == Arguments.Length)
            //{
            //    ret = String.Format("Command {0} should have {1} arguments", tempStr[0], Arguments.Length);
            //    return ret;
            //}


            //for(int i=0; i < Arguments.Length;i++)
            //{
            //    switch(Arguments[i])
            //    {
            //        case ArgumentType.String:
                        
            //            break;

            //        case ArgumentType.integer:
            //            if(int.TryParse(tempStr[i+1],out int Number) == true)
            //            {
                             
            //            }
            //            break;

            //        case ArgumentType.HexString:
            //            break;

            //        case ArgumentType.int16:
            //            break;

            //        default:
            //            break;
            //    }
            //}


            return ret;
        }
    }
}
