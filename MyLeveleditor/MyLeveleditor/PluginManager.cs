using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;

using MapAPI;

namespace MyLeveleditor
{
    public static class PluginManager
    {
        /*
        /// <summary>
        /// compiles the specified VB source code in memory, and will then attempt to extract any classes that
        /// implement the FileTranslator interface
        /// </summary>
        /// <param name="source"> the source code as Visual Basic </param>
        /// <returns> void </returns>
        public static void ExecuteVB(string source)
        {
            VBCodeProvider prov = new VBCodeProvider();
            ICodeCompiler compiler = prov.CreateCompiler();
            ExecuteScript(compiler, source);
        }

        /// <summary>
        /// Compiles the specified C# source code in memory, and will then attempt to extract any classes that
        /// implement the FileTranslator interface
        /// </summary>
        /// <param name="source"> the source code as C# </param>
        /// <returns> void </returns>
        public static void ExecuteCS(string source)
        {
            CSharpCodeProvider prov = new CSharpCodeProvider();
            ICodeCompiler compiler = prov.CreateCompiler();
            ExecuteScript(compiler, source);
        }
        */

        /// <summary>
        /// loads the specified dll, and will then attempt to extract any classes that
        /// implement the FileTranslator interface
        /// </summary>
        /// <param name="dllname"></param>
        /// <returns></returns>
        public static void LoadPlugin(string dllname)
        {
            Assembly assembly = Assembly.LoadFrom(dllname);
            if (assembly == null)
            {
                throw new Exception("Dll could not be loaded.");
            }
            InvokeAssembly(assembly);
        }

        /// <summary>
        /// Searches through the compiled assembly a, and looks at all classes contained within it. 
        /// If it finds any that implement the FileTranslator interface, it will register them with
        /// the FileTranslatorManager
        /// </summary>
        /// <param name="a"> The compiled assembly </param>
        /// <returns> void </returns>
        private static void InvokeAssembly(Assembly a)
        {
            // search all classes in the compiled assembly
            foreach (Type t in a.GetTypes())
            {
                // check to see if this type has the FileTranslator interface
                if (null != t.GetInterface("FileTranslator"))
                {
                    // create an instance of it
                    object result = a.CreateInstance(t.FullName);
                    FileTranslator ft = (FileTranslator)result;
                    if (ft != null)
                    {
                        FileTranslatorManager.RegisterTranslator(ft);
                    }
                }
            }
        }
        /*
        /// <summary>
        /// Given some source code, and the interface to a compiler (VB or C#), this function
        /// will add the required assemblies, and attempt to compile the code. If successful, 
        /// an Assembly will be produced that will be passed to InvokeAssembly(). If it fails, 
        /// a list of compile errors will be displayed in a message box
        /// </summary>
        /// <param name="compiler"> the compiler interface </param>
        /// <param name="code"> the source code to compile </param>
        /// <returns> void </returns>
        private static void ExecuteScript(ICodeCompiler compiler, string code)
        {
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;

            //
            // Add any default libs
            //
            cp.ReferencedAssemblies.Add("system.dll");
            cp.ReferencedAssemblies.Add("system.data.dll");
            cp.ReferencedAssemblies.Add("system.drawing.dll");
            cp.ReferencedAssemblies.Add("system.windows.forms.dll");

            //
            // Add reference to the core dll(s) of the application. The scripts
            // will then be able to access the core functionality of the app.
            //
            cp.ReferencedAssemblies.Add("MapAPI.dll");

            CompilerResults cr;
            cr = compiler.CompileAssemblyFromSource(cp, code);

            // Check for any errors in the script
            if (cr.Errors.HasErrors)
            {
                StringBuilder sbErr;
                sbErr = new StringBuilder();
                foreach (CompilerError err in cr.Errors)
                {
                    sbErr.AppendFormat("{0} at line {1} column {2} ",
                         err.ErrorText,
                         err.Line,
                         err.Column);
                    sbErr.Append("\n");
                }
                throw new Exception (sbErr.ToString());
            }

            // Get the assembly code generated
            Assembly a = cr.CompiledAssembly;
            try
            {
                InvokeAssembly(a);
            }
            catch (Exception ex)
            {
                throw new Exception("Script could not be invoked.\n" + ex.Message);
            }
        }
        */
    }
}
