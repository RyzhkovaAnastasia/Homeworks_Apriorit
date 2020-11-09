import QuestionList from './QuestionList'
import {useHistory} from 'react-router-dom'

function Home() {

const history = useHistory();

function addQuestion() {
    history.push('/add');
}

    return (
        <div className="Home">
            <h1 className="p-3">
                Stack Overflow
          </h1>
            <div className="d-flex p-3">
                <button className="btn btn-primary float-left" onClick={addQuestion}>Create new question</button>
            </div>
            <QuestionList />
        </div>
    );
}

export default Home;