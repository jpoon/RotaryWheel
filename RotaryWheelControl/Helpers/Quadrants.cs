// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace RotaryWheelUserControl.Helpers
{
    using System;
    using Windows.Foundation;

    public class QuadrantHelper
    {
        public enum Quadrants
        {
            NE = 0,
            SE,
            SW,
            NW,
        };

        public static Quadrants GetQuadrant(double angle)
        {
            return (angle <= 90)
                ? Quadrants.NE
                : (angle <= 180)
                    ? Quadrants.SE
                    : (angle <= 270) ? Quadrants.SW : Quadrants.NW;
        }

        public static Point Calculate(double radius, double startAngle, double angle)
        {
            var halfAngle = startAngle + angle/2;

            var quadrant = GetQuadrant(halfAngle);
            var quadrantAngle = halfAngle - 90*(int)quadrant;

            var adjacent = Math.Cos(Math.PI/180* quadrantAngle) *radius;
            var opposite = Math.Sin(Math.PI/180* quadrantAngle) *radius;

            switch (quadrant)
            {
                case Quadrants.NE:
                    return new Point(opposite, -1*adjacent);

                case Quadrants.SE:
                    return new Point(adjacent, opposite);

                case Quadrants.SW:
                    return new Point(-1*opposite, adjacent);

                case Quadrants.NW:
                    return new Point(-1*adjacent, -1*opposite);

                default:
                    throw new NotSupportedException();
            }
        }

        public static double GetAngle(Point touchPoint, Size circleSize)
        {
            var x = touchPoint.X - (circleSize.Width / 2d);
            var y = circleSize.Height - touchPoint.Y - (circleSize.Height / 2d);
            var hypot = Math.Sqrt(x * x + y * y);
            var value = Math.Asin(y / hypot) * 180 / Math.PI;
            var quadrant = (x >= 0) ?
                (y >= 0) ? Quadrants.NE : Quadrants.SE :
                (y >= 0) ? Quadrants.NW : Quadrants.SW;

            switch (quadrant)
            {
                case Quadrants.NE:
                    value = 090 - value;
                    break;

                case Quadrants.NW:
                    value = 270 + value;
                    break;

                case Quadrants.SE:
                    value = 090 - value;
                    break;

                case Quadrants.SW:
                    value = 270 + value;
                    break;
            }

            return value;
        }
    }
}
