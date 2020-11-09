import React, { useEffect, useState } from 'react';
import questService from '../services/QuestionService'
import { Link } from 'react-router-dom';


export default function QuestionsList() {
  const [questions, setQuestions] = useState([]);
  const [answers, setAnswers] = useState([]);

  useEffect(() => {
    questService.getQuestions().then(quest => {
      setQuestions(quest);
    }).catch(err => {
      console.log(err);
    });
  }, []);

  useEffect(() => {
    questService.getQuestions().then(answ => {
      setAnswers(answ);
    }).catch(err => {
      console.log(err);
    });
  }, []);


  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th>Views</th>
          <th>Answers</th>
          <th>Question</th>
          <th>Date</th>
          <th>Author</th>
        </tr>
      </thead>
      <tbody>
        {questions
          .map(question => {
            return (
              <>
              <tr key={question.id}>
                <td> {question.viewNumber} </td>
                <td> {question.answerNumber} </td>
                <td> <Link to={'question/' + question.id}>{question.title}</Link> </td>
                <td> {new Date(question.creationDateTime).toLocaleDateString()} </td>
                <td> {question.author} </td>
              </tr>
              </>
            )
          }
          )
        }
      </tbody>
    </table>
  );
}