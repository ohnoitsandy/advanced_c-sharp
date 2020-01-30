using System;
using System.Collections;
using System.Collections.Generic;
using CoreSchool.Entities;

namespace CoreSchool.App
{
    public class Reporter
    {
        private Dictionary<DictionaryKey, IEnumerable<BaseSchoolObject>> _dictionary;
        public Reporter (Dictionary<DictionaryKey,
            IEnumerable<BaseSchoolObject>> schoolObjectDictionary)
        {
            if (schoolObjectDictionary == null)
            {
                throw new ArgumentNullException(nameof(schoolObjectDictionary));
            }
            _dictionary = schoolObjectDictionary;
        }

       /* public IEnumerable<Evaluation> GetListOfEvaluations()
        {
            _dictionary[DictionaryKey.Evaluation]
        }
        */
    }
}