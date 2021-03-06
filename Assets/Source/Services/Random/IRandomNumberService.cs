﻿namespace Source.Services.Random
{
    public interface IRandomNumberService
    {
        /// <summary>
        /// Return a random integer between minInclusive and maxExclusive
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        /// <returns></returns>
        int Range(int minInclusive, int maxExclusive);

        /// <summary>
        /// Return a random float between minInclusive and maxExclusive
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        /// <returns></returns>
        float Range(float minInclusive, float maxExclusive);

        /// <summary>
        /// Return a random double between minInclusive and maxExclusive
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        /// <returns></returns>
        double Range(double minInclusive, double maxExclusive);
    }
}
