namespace JustBlueberry
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;
    using JustBlueberry.Extensions;
    using JustBlueberry.Interfaces;
    using System.Text;


    public class Engine
    {
        private IOperator hadronOperator;
        private IList<IMatter> substance;
        private IRenderer renderer;
        private int threadSleepParam;

        public Engine(IRenderer renderer, IOperator hadronOperator, IList<IMatter> substance, int threadSleepParam = 500)
        {
            this.Renderer = renderer;
            this.HadronOperator = hadronOperator;
            this.Substance = substance;
            this.ThreadSleepParam = threadSleepParam;
        }

        public int ThreadSleepParam
        {
            get { return this.threadSleepParam; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ThreadSleep parameter must be larger than zero.");
                }
                this.threadSleepParam = value;
            }
        }

        public IRenderer Renderer
        {
            get { return this.renderer; }
            set
            {
                if (value == null)
                {
                    // TODO: throw new RendererMissingException
                }
                this.renderer = value;
            }
        }

        private IOperator HadronOperator
        {
            get { return this.hadronOperator; }
            set
            {
                if (value == null)
                {
                    // TODO: throw new HadronMissingException
                }
                this.hadronOperator = value;
            }
        }

        private IList<IMatter> Substance
        {
            get { return this.substance; }
            set
            {
                if (value == null)
                {
                    throw new InvalidBlueberryException("No blueberries, man...");
                }
                this.substance = value;
            }
        }

        public void AddHadron(IMatter matter)
        {
            this.substance.Add(matter);
        }

        public void Run()
        {
            // Set Console parameters.
            SetConsole();

            // Central / Game loop.
            while (true)
            {
                // Update all particles' positions.
                Update();

                // Process the particles by stacking them updated for rendering.
                Process();

                // Perform rendering operations.
                Render();

                // Ensure constant app flow.
                Thread.Sleep(this.ThreadSleepParam);
            }
        }

        private void Render()
        {
            // Render current frame and release all particles from rendering.
            renderer.Print();
            renderer.Release();

            // Perform end-of-frame actions.
            hadronOperator.EndFrame();
        }

        private void Process()
        {
            // Filter only renderable particles and then push them for rendering (prevents unwanted exception throw).
            this.Substance.ForEach(x => x.Particles.Where(y => y is IRenderable).ForEach(z => renderer.Push(z as IRenderable)));
        }

        private void Update()
        {
            // Update all available particles (both renderable and not renderable).
            substance.ForEach(x => x.Particles.ForEach(y => hadronOperator.OperateOn(y)));
        }

        private void SetConsole()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 95;
            Console.BufferHeight = 40;
            Console.BufferWidth = 100;
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "JustBlueberries";
        }
    }
}
