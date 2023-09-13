using DexonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DexonApi.Services
{
    public class CmlService
    {
        private readonly Dictionary<float, float> _pipeSizeAODMap;

        public CmlService()
        {
            _pipeSizeAODMap = new Dictionary<float, float>
            {
                {0.125f, 10.3f},
                {0.25f, 13.7f},
                {0.357f, 17.1f},
                {0.5f, 21.3f},
                {0.75f, 26.7f},
                {1, 33.4f},
                {1.25f, 42.2f},
                {1.5f, 48.3f},
                {2, 60.3f},
                {2.5f, 73f},
                {3, 88.9f},
                {3.5f, 101.6f},
                {4, 114.3f},
                {5, 141.3f},
                {6, 168.3f},
                {8, 219.1f},
                {10, 273f},
                {12, 323.8f},
                {14, 355.6f},
                {16, 406.4f},
                {18, 457}
            };
        }

        public float GetAOD(float pipeSize)
        {
            if (_pipeSizeAODMap.ContainsKey(pipeSize))
            {
                return _pipeSizeAODMap[pipeSize];
            }
            else
            {
                return 0;
            }
        }

        public float GetStThickness(float pipeSize)
        {
            if (pipeSize <= 2)
            {
                return 1.8f;
            }
            else if (pipeSize == 3)
            {
                return 2.0f;
            }
            else if (pipeSize == 4)
            {
                return 2.3f;
            }
            else if (pipeSize >= 6 || pipeSize <= 18)
            {
                return 2.8f;
            }
            else if (pipeSize >= 20)
            {
                return 3.1f;
            }
            else return 0;
        }

        public float GetDesignThickness(Info info, Cml cml)
        {
            float result = (info.DesignPressure * cml.ActualOutsideDiameter);
            if (result == 0)
            {
                return 0;
            }
            result = result / ((2 * info.Stress * info.JointEfficiency) + (2 * 0.4f * info.DesignPressure));
            return result;

        }
    }
}
