// [Ready Design Corps] - [Mahjong Event Coordinator] - Copyright 2023

using MahjongCore.Common;
using System;
using System.Collections.Generic;

namespace MahjongEventCoordinator.Model
{
    public class BaseModel
    {
        protected void AssignToProp<T>(Action handler, out T outProp, T inProp, T value, bool checkValue = true) where T : IComparable
        {
            CommonHelpers.Check(checkValue, "Value not valid!");
            if ((inProp == null) || (inProp.CompareTo(value) != 0))
            {
                outProp = value;
                handler?.Invoke();
            }
            else
            {
                outProp = inProp;
            }
        }

        protected void AssignToProp2<T>(Action handler, out T outProp, T inProp, T value, bool checkValue = true) where T : IComparable<T>
        {
            CommonHelpers.Check(checkValue, "Value not valid!");
            if ((inProp == null) || (value == null) || ( inProp.CompareTo(value) != 0))
            {
                outProp = value;
                handler?.Invoke();
            }
            else
            {
                outProp = inProp;
            }
        }

        protected void AssignToProp3<T>(Action handler, out T outProp, T inProp, T value, bool checkValue = true) where T : IEquatable<T>
        {
            CommonHelpers.Check(checkValue, "Value not valid!");
            if ((inProp == null) || inProp.Equals(value))
            {
                outProp = value;
                handler?.Invoke();
            }
            else
            {
                outProp = inProp;
            }
        }

        protected void AssignToListProp<T>(Action handler, out List<T> outProp, List<T> inProp, List<T> value, bool checkValue = true)
        {
            CommonHelpers.Check(checkValue, "Value not valid!");
            if ((inProp == null) || (inProp != value))
            {
                outProp = value;
                handler?.Invoke();
            }
            else
            {
                outProp = inProp;
            }
        }
    }
}
