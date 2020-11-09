import questService from '../services/QuestionService';
import answService from '../services/AnswerService';
import React, { useEffect, useState } from 'react';
import { Container } from 'react-bootstrap';
import { useParams } from "react-router-dom";
import AnswersForm from './AddAnswerForm';

export default function Question() {
    const [question, setQuestion] = useState(null);
    const [answers, setAnswers] = useState([]);
    const { id } = useParams();

    useEffect(getQuestion, []);
    useEffect(getAnswers, []);
    

    function getQuestion() {
        questService.getQuestionById(id).then(quest => {
            setQuestion(quest);
        }).catch(err => {
            console.error(err);
        });
        questService.incremetViews(id);
    }

    function getAnswers() {
        answService.getAnswers(id).then(answ => {
            setAnswers(answ);
        }).catch(err => {
            console.error(err);
        });
    }

    function DisplayQuestion() {
        let date = new Date(question.creationDateTime).toLocaleDateString();
        return (
            <>
                <div className="pb-3">
                    <h2>{question.title}</h2>
                    <small className="mr-5">Date: {date}</small>
                    <small>Author: {question.author}</small>
                    <div className="mt-3 py-3">
                        {question.description}
                    </div>
                </div>
                <div className="pt-5">
                    <h5>Answers</h5>
                </div>
            </>
        );
    }

    function DisplayAnswer() {
        return answers.map(answer => {
            return (
                <div key={answer.id} className=" p-3 mb-2 d-flex flex-column border">
                    <pre>{answer.answerText}</pre>
                </div>
            );
        });
    }

    function answerAdd() {
        getAnswers();
    }

    return (
        <Container className="mt-3">
            {question ? (
                <>
                    <DisplayQuestion />
                    <DisplayAnswer />
                    <AnswersForm questId={question.id} onAnswerAdd={answerAdd} />
                </>
            ) : (
                    <p>Loading...</p>
                )}
        </Container>
    );
};