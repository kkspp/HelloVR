using UnityEngine;
using System.Collections;
using System;

public class Userdata
{
    public UphiiData uphil;
    public SignalLightData signal;
    public ParkingData parking;
    public UnexpectedData unexcepted;
    public AccelationData accelation;
    public string start;//시작시간과 종료시간
    public string end;
    public string score;//과속점수감점
    public string disqualification;//실격
    public Userdata()
    {
        uphil = new UphiiData();
        signal = new SignalLightData();
        parking = new ParkingData();
        unexcepted = new UnexpectedData();
        accelation = new AccelationData();
        score = "0";
        disqualification = "";
    }
    public string getDisqualification()
    {
        return disqualification;
    }
    public void setDisqualification(string dis)
    {
        this.disqualification = dis;
    }
    public string getStart()
    {
        return start;
    }
    public void setStart()
    {
        String time;
        time = DateTime.Now.ToString("yyyy년MM월dd일 HH:mm:ss");
        this.start = time;
    }
    public void setEnd()
    {
        String time;
        time = DateTime.Now.ToString("yyyy년MM월dd일 HH:mm:ss");
        this.end = time;
    }
    public string getEnd()
    {
        return end;
    }
    public string getScore()
    {
        return this.score;
    }
    public void setScore(string score)
    {
        int temp = 0;
        if (this.score == null)
        {
            temp = int.Parse(score);
        }
        else
        {
            temp = (int.Parse(this.score) + int.Parse(score));
        }
        this.score = temp.ToString();
    }
}

public class UphiiData
{
    public string Success;//성공여부+들어갔는지안들어갔는지.
    public string score;//총감점
    public string scoreReason;//
    public string start;//시작시간과 종료시간
    public string end;

   public UphiiData()
    {
        Success = "None";
        score = "0";
    }
    public string getScore()
    {
        return score;
    }

    public void setScore(string score)
    {
        int temp = 0;
        if (this.score == null) {
            temp = int.Parse(score);
        }
        else
        {
            temp = (int.Parse(this.score) + int.Parse(score));
        }
        this.score = temp.ToString();
    }

    public string getScoreReason()
    {
        return scoreReason;
    }

    public void setScoreReason(string scoreReason)
    {
        this.scoreReason = scoreReason;
    }

    public string getSuccess()
    {
        return Success;
    }
    public void setSuccess(string Success)
    {
        this.Success = Success;
    }
    public string getStart()
    {
        return start;
    }
    public void setStart()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.start = time;
    }
    public void setEnd()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.end = time;
    }
    public string getEnd()
    {
        return end;
    }
}
public class SignalLightData
{
    public string Success;//성공여부
    public string score;//총감점
    public string scoreReason;//감점사유
    public string start;//시작시간과 종료시간
    public string end;

   public SignalLightData()
    {
        Success = "None";
        score = "0";
    }
    public string getScore()
    {
        return score;
    }

    public void setScore(string score)
    {
        int temp = 0;
        if (this.score == null)
        {
            temp = int.Parse(score);
        }
        else
        {
            temp = (int.Parse(this.score) + int.Parse(score));
        }
        this.score = temp.ToString();
    }

    public string getScoreReason()
    {
        return scoreReason;
    }

    public void setScoreReason(string scoreReason)
    {
        this.scoreReason = scoreReason;
    }

    public string getSuccess()
    {
        return Success;
    }

    public void setSuccess(string success)
    {
        Success = success;
    }
    public string getStart()
    {
        return start;
    }
    public void setStart()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.start = time;
    }
    public void setEnd()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.end = time;
    }
    public string getEnd()
    {
        return end;
    }
}
public class ParkingData
{
    public string Success;//성공여부
    public string score;//총감점
    public string scoreReason;//감점사유
    public string start;//시작시간과 종료시간
    public string end;

   public ParkingData()
    {
        Success = "None";
        score = "0";
    }
    public string getScore()
    {
        return score;
    }

    public void setScore(string score)
    {
        int temp = 0;
        if (this.score == null)
        {
            temp = int.Parse(score);
        }
        else
        {
            temp = (int.Parse(this.score) + int.Parse(score));
        }
        this.score = temp.ToString();
    }

    public string getScoreReason()
    {
        return scoreReason;
    }

    public void setScoreReason(string scoreReason)
    {
        this.scoreReason = scoreReason;
    }

    public string getSuccess()
    {
        return Success;
    }

    public void setSuccess(string success)
    {
        Success = success;
    }
    public string getStart()
    {
        return start;
    }
    public void setStart()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.start = time;
    }
    public void setEnd()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.end = time;
    }
    public string getEnd()
    {
        return end;
    }
}
public class UnexpectedData
{
    public string Success;//성공여부
    public string score;//총감점
    public string scoreReason;//감점사유
    public string start;//시작시간과 종료시간
    public string end;

   public UnexpectedData()
    {
        Success = "None";
        score = "0";
    }
    public string getScore()
    {
        return score;
    }

    public void setScore(string score)
    {
        int temp = 0;
        if (this.score == null)
        {
            temp = int.Parse(score);
        }
        else
        {
            temp = (int.Parse(this.score) + int.Parse(score));
        }
        this.score = temp.ToString();
    }

    public string getScoreReason()
    {
        return scoreReason;
    }

    public void setScoreReason(string scoreReason)
    {
        this.scoreReason = scoreReason;
    }

    public string getSuccess()
    {
        return Success;
    }

    public void setSuccess(string success)
    {
        Success = success;
    }
    public string getStart()
    {
        return start;
    }
    public void setStart()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.start = time;
    }
    public void setEnd()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.end = time;
    }
    public string getEnd()
    {
        return end;
    }
}
public class AccelationData
{
    public string Success;//성공여부
    public string score;//총감점
    public string scoreReason;//감점사유
    public string start;//시작시간과 종료시간
    public string end;

   public AccelationData()
    {
        Success = "None";
        score = "0";
    }
    public string getScore()
    {
        return score;
    }

    public void setScore(string score)
    {
        int temp = 0;
        if (this.score == null)
        {
            temp = int.Parse(score);
        }
        else
        {
            temp = (int.Parse(this.score) + int.Parse(score));
        }
        this.score = temp.ToString();
    }

    public string getScoreReason()
    {
        return scoreReason;
    }

    public void setScoreReason(string scoreReason)
    {
        this.scoreReason = scoreReason;
    }

    public string getSuccess()
    {
        return Success;
    }

    public void setSuccess(string success)
    {
        Success = success;
    }

    public string getStart()
    {
        return start;
    }
    public void setStart()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.start = time;
    }
    public void setEnd()
    {
        String time;
        time = DateTime.Now.ToString("HH:mm:ss");
        this.end = time;
    }
    public string getEnd()
    {
        return end;
    }
}
