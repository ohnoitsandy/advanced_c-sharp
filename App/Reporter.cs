using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Evaluation> GetListOfEvaluations()
        {
            IEnumerable<School> response;
            if (_dictionary.TryGetValue(DictionaryKey.Evaluation,
                out IEnumerable<BaseSchoolObject> list))
            {
                return list.Cast<Evaluation>();
            }

            {
                return new List<Evaluation>();
            }
        }

        public IEnumerable<string> GetListOfSubjects()
        {
            var evaluationList = GetListOfEvaluations();

            return (from evaluation in evaluationList
                select evaluation.Name).Distinct();
        }
        
        public Dictionary<string, IEnumerable<Evaluation>> GetEvaluationsListBySubject()
        {
            var dictionaryOfSubjectsByEvaluation = new Dictionary<string, IEnumerable<Evaluation>>();
            return dictionaryOfSubjectsByEvaluation;
        }
    }
}