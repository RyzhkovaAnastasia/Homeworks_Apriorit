import { useForm } from 'react-hook-form';
import answerService  from '../services/AnswerService'
import { Link } from 'react-router-dom';

export default function AnswersForm(props) {
  const { register, handleSubmit, errors } = useForm();
  const onSubmit = (data, e) => {
    e.target.reset();
    data.questionId = props.questId;
    answerService.createAnswer(data).then(answer => {
      props.onAnswerAdd(answer);
    });
  }

  return (
    <div className="py-3">
      <h5 className="mb-3">Create your answer</h5>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="form-group">
          <textarea
            name="answerText"
            placeholder="Enter your answer"
            className={errors.answerText ? 'form-control is-invalid' : 'form-control'}
            ref={register({ required: "Answer required" })}
            rows="3"
          />
          {errors.answerText && <small className="form-text text-danger">{errors.answerText.message}</small>}
        </div>
        <input type="submit" className="btn btn-primary" value="Add answer"/>
        <button className="btn"><Link to={'/'}>Back</Link></button>
      </form>
    </div>
  );
}