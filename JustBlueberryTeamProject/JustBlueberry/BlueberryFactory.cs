namespace JustBlueberry
{
    using JustBlueberry.Interfaces;
    using System.Collections.Generic;

    public static class BlueberryFactory
    {
        public static IMatter CreateDarkBlueberry(Vector translationVector)
        {
            return new DarkBlueberry(
                                    new List<IHadron>()
                                    {
                                        new Proton(new Point(5, 7) + translationVector),
                                        new Proton(new Point(8, 12) + translationVector),
                                        new Proton(new Point(4, 5) + translationVector),
                                        new Proton(new Point(9, 14) + translationVector),
                                        new WhiteElectron(new Point(2,7) + translationVector),
                                        new BlackElectron(new Point(4,0) + translationVector)
                                    }
                                 );
        }

        public static IMatter CreateNervousBlueberry(Vector translationVector)
        {
            return new NervousBlueberry(new List<IHadron>() 
                                        {
                                            new Proton(new Point(11, 11) + translationVector),
                                            new RedElectron(new Point(12, 15) + translationVector),
                                            new BlueElectron(new Point(11, 11) + translationVector),
                                            new GreenElectron(new Point(11, 11) + translationVector)
                                        }
                                      );
        }
    }
}
