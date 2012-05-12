using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CooperativeSokoban
{
    enum LevelLoadingResult
    {
        OK, 
        FileNotFound, 
        InvalidLevel
    }
    
    class LevelLoader
    {
        public static LevelLoadingResult loadLevel(string filename)
        {
            string szSrcLine;
            FileStream fsInput;
            try
            {
                fsInput = new FileStream(filename, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                return LevelLoadingResult.FileNotFound;
            }
            StreamReader srInput = new StreamReader(fsInput);

            while ((szSrcLine = srInput.ReadLine()) != null)
            {
                // hier Zeile verarbeiten....
            }
            srInput.Close();
            fsInput.Close();

            return LevelLoadingResult.OK;
        }
    }
}
