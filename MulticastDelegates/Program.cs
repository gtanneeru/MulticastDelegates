using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegates
{
    public delegate void sampleDelegate();
    public delegate int returnTypeDelegate();
    public delegate void withOutParameter(out int integer);

    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();

            sampleDelegate del1, del2, del3, del4;
            del1 = new sampleDelegate(prog.sampleFunctionOne);
            del2 = new sampleDelegate(prog.sampleFunctionTwo);
            del3 = new sampleDelegate(prog.sampleFunctionThree);
            del4 = del1 + del2 + del3-del2;
            del4();// Multicast delegate
//A delegate that points to more than one function is called Multicast delegate          


            sampleDelegate del = new sampleDelegate(prog.sampleFunctionOne);
            del += new sampleDelegate(prog.sampleFunctionTwo);
            del += new sampleDelegate(prog.sampleFunctionThree);
            del -= new sampleDelegate(prog.sampleFunctionOne);
            del(); // Another way of pointing morethan one function to one deligate, Multicast delegate.

// delegate with return type
            returnTypeDelegate returnTypeDelegate = new returnTypeDelegate(prog.anotherType1);
            returnTypeDelegate += new returnTypeDelegate(prog.anotherType2);
    
           int delegateReturnValue = returnTypeDelegate();
            Console.WriteLine("delegateReturnValue: {0}", delegateReturnValue);

  //delegate with "out" parameter
            withOutParameter thirdType = new withOutParameter(prog.withOutParameter1);
            thirdType += new withOutParameter(prog.withOutParameter2);
 // Even though int valueOfDelegateWithParameterOut is assigned -1, when it is passed to the delegate method, 
 // the last value from the method is stored in the int variable.

            int valueOfDelegateWithParameterOut = -1;
            thirdType(out valueOfDelegateWithParameterOut);

            Console.ReadKey();
        }
        public void sampleFunctionOne()
        {
            Console.WriteLine("sampleFunctionOne Invoked");
        }
        public void sampleFunctionTwo()
        {
            Console.WriteLine("sampleFunctionTwo Invoked");
        }
        public void sampleFunctionThree()
        {
            Console.WriteLine("sampleFunctionThree Invoked");
        }
        public int anotherType1()
        {
            return 1;
        }
        public int anotherType2()
        {
            return 2;
        }
        public void withOutParameter1(out int number)
        {
            number = 1;
        }
        public void withOutParameter2(out int number)
        {
            number = 2;
        }
    }
}
