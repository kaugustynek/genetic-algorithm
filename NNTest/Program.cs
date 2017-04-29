using System;
using FANNCSharp;
using FANNCSharp.Double;

namespace XorTrain
{
    class XorTrain
    {

        static int PrintCallback(NeuralNet net, TrainingData train, uint max_epochs, uint epochs_between_reports, float desired_error, uint epochs, Object user_data)
        {
            Console.WriteLine(String.Format("Epochs     " + String.Format("{0:D}", epochs).PadLeft(8) + ". Current Error: " +
                              String.Format("{0:F5}", net.MSE).PadRight(8)));
            return 0;
        }

        static void XorTest()
        {
            const float learning_rate = 0.9f;
            const uint num_layers = 4;
            const uint num_input = 1;
            const uint num_hidden1 = 15;
            const uint num_hidden2 = 8;
            const uint num_hidden3 = 4;
            const uint num_output = 1;
            const float desired_error = 0.001f;
            const uint max_iterations = 3000000;
            const uint iterations_between_reports = 1000;

            Console.WriteLine("\nCreating network.");

            using (NeuralNet net = new NeuralNet(NetworkType.LAYER, num_layers, num_input, num_hidden1, num_hidden2, num_output))
            {
                net.LearningRate = learning_rate;

                //net.ActivationSteepnessHidden = 1.0F;
                //net.ActivationSteepnessOutput = 1.0F;

                net.ActivationFunctionHidden = ActivationFunction.SIGMOID_SYMMETRIC;
                net.ActivationFunctionOutput = ActivationFunction.SIGMOID_SYMMETRIC;

                // Output network type and parameters
                Console.Write("\nNetworkType                         :  ");
                switch (net.NetworkType)
                {
                    case NetworkType.LAYER:
                        Console.WriteLine("LAYER");
                        break;
                    case NetworkType.SHORTCUT:
                        Console.WriteLine("SHORTCUT");
                        break;
                    default:
                        Console.WriteLine("UNKNOWN");
                        break;
                }
                net.PrintParameters();

                Console.WriteLine("\nTraining network.");

                using (TrainingData data = new TrainingData())
                {
                    if (data.ReadTrainFromFile("data.txt"))
                    {
                        data.ScaleInputTrainData(-1, 1);
                        data.ScaleOutputTrainData(-1, 1);

                        // Initialize and train the network with the data
                        net.InitWeights(data);
                        net.TrainingAlgorithm = TrainingAlgorithm.TRAIN_RPROP;

                        Console.WriteLine("Max Epochs " + String.Format("{0:D}", max_iterations).PadLeft(8) + ". Desired Error: " + String.Format("{0:F}", desired_error).PadRight(8));
                        net.SetCallback(PrintCallback, null);
                        net.TrainOnData(data, max_iterations, iterations_between_reports, desired_error);

                        Console.WriteLine("\nTesting network.");

                        for (uint i = 0; i < data.TrainDataLength; i++)
                        {
                            // Run the network on the test data
                            double[] calc_out = net.Run(data.Input[i]);

                            Console.WriteLine($"{data.InputAccessor[(int)i][0]}\t{data.Output[i][0]}\t{calc_out[0]}");
                        }

                        Console.WriteLine("\nSaving network.");

                        // Save the network in floating point and fixed point
                        net.Save("xor_float.net");
                        uint decimal_point = (uint)net.SaveToFixed("xor_fixed.net");
                        data.SaveTrainToFixed("xor_fixed.data", decimal_point);

                        Console.WriteLine("\nXOR test completed.");
                    }
                }
            }
        }
        static int Main(string[] args)
        {
            try
            {
                XorTest();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("\nAbnormal exception.");
            }
            Console.ReadKey();
            return 0;
        }
    }
}