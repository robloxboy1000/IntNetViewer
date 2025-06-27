using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntNetViewer
{
    public class ActionHandler
    {
        public static void DoAction(Action action, bool invoke = true)
        {
            if (invoke)
            {
                if (action != null)
                {
                    action.Invoke();
                }
            }
            else
            {
                if (action != null)
                {
                    action.BeginInvoke(null, null);
                }
            }
        }
        public static void DoActionEverySetTime(Action action, bool invoke = true, int milliseconds = 1000)
        {
            if (invoke)
            {
                if (action != null)
                {
                    action.Invoke();
                }
            }
            else
            {
                if (action != null)
                {
                    Task.Run(async () =>
                    {
                        while (true)
                        {
                            action.Invoke();
                            await Task.Delay(milliseconds);
                        }
                    });
                }
            }
        }
        
    }
}
