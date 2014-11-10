/*
Coded by Kevin Reynolds
*/

public class Door
{
    private int _state; // 0 = open, 1 = closed, 2 = locked
	private Question _question;

    public Door(Question question)
    {
        _state = 1;
		_question = question;
    }
	
	public int State
	{
		get
		{
			return this._state;
		}
		set
		{
			this._state = value;
		}
	}
	
	public bool isDoorOpen()
	{
		// return false if locked
		if (_state == 2) 
			return false;
		
		// return true if open
		if (_state == 0)
			return true;
			
		return _question.askQuestion(); //return true if answered correctly
	}
}