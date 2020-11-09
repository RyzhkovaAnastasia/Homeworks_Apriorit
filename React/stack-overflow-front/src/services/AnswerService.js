import env from '../app-settings';
import axios from 'axios';

const ax = require('axios');

axios.defaults.baseURL = env.apiUrl;

async function createAnswer(newAnswer) {
  try {
    const response = await ax.post('/answer', newAnswer);
    return await JSON.parse(response.request.response);
  } catch (error) {
    console.error(error);
  }
}

async function getAnswers(questionId) {
  try {
    const response = await ax.get(`/answer/${questionId}`);
    return await JSON.parse(response.request.response);
  } catch (error) {
    console.error(error);
  }
}

export default {
  createAnswer,
  getAnswers
}