﻿// This file was auto-generated by ML.NET Model Builder.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.LightGbm;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace Tempml_WebApi
{
    public partial class Tempml
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"OutTemp", @"OutTemp"),new InputOutputColumnPair(@"HeatStateSince", @"HeatStateSince"),new InputOutputColumnPair(@"StartTemp", @"StartTemp")})      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"OutTemp",@"HeatStateSince",@"StartTemp"}))      
                                    .Append(mlContext.Regression.Trainers.LightGbm(new LightGbmRegressionTrainer.Options(){NumberOfLeaves=6211,NumberOfIterations=7501,MinimumExampleCountPerLeaf=20,LearningRate=0.00328148931305259,LabelColumnName=@"RoomTemp",FeatureColumnName=@"Features",ExampleWeightColumnName=null,Booster=new GradientBooster.Options(){SubsampleFraction=0.999999776672986,FeatureFraction=0.99999999,L1Regularization=4.88584960641919E-07,L2Regularization=0.804067582831107},MaximumBinCountPerFeature=187}));

            return pipeline;
        }
    }
}