import env from '../app-settings';

var ax = require('axios');

ax.defaults.baseURL = env.apiUrl;

async function getQuestions() {
  try {
    const response = await ax.get('/question');
    return await JSON.parse(response.request.response);
  } catch (error) {
    console.error(error);
  }
}

async function getQuestionById(id) {
    try {
      const response = await ax.get(`/question/${id}`);
      return await JSON.parse(response.request.response);
    } catch (error) {
      console.error(error);
    }
  }

async function addQuestion(question) {
  try {
    question['creationDateTime'] = new Date().toJSON();
    const response = await ax.post('/question', question);
    return await JSON.parse(response.request.response);
  } catch (error) {
    console.error(error);
  }
}

async function incremetViews(id) {
  try {
    const response = await ax.post(`/question/${id}`);
    return await JSON.parse(response.request.response);
  } catch (error) {
    console.error(error);
  }
}

export default {
  getQuestions,
  getQuestionById,
  addQuestion,
  incremetViews
}