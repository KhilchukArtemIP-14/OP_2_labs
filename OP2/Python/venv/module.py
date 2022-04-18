from pickle import dump
from pickle import load
from os.path import exists


def GetDirectoria():
    name = input('Please, input the name of your file\n')
    return 'C:\\Users\\Artem\\Desktop\\forOP\\' + name + '.bin'


def ConvertTimeToMins(stringOfTime):
    hours = int(stringOfTime[:stringOfTime.index(':')])
    minutes = int(stringOfTime[stringOfTime.index(':') + 1:])
    return hours * 60 + minutes


def GetTimeOfEnd(start):
    time = ConvertTimeToMins(start) + 105
    hours = time // 60
    minutes = time % 60
    result = "{hod:02d}:{hv:02d}".format(hod=hours, hv=minutes)
    print('Lecture would end at {end}\n'.format(end=result))
    return result


def DeserializeFile(path):
    pari = []
    if (exists(path)):
        with open(path, 'rb') as file:
            while True:
                try:
                    temp = load(file)
                except EOFError:
                    break
                pari.append(temp)
            #print('Note: last lecture ended at {yes}'.format(yes= data[-1]['endTime']))
            return pari, pari[-1]['endTime']
    else:
        return pari, -1

def PrintOutRozklad(pari):
    if len(pari)!=0:
        print('Name of lecture---------Start-----End\n')
        for para in pari:
            print(para['Name'].ljust(24,'-')+para['startTime'].ljust(10,'-')+para['endTime']+'\n')
    else:
        print("Note: no lectures were previously assigned\n")

def GetTimeOfStart(lastParaTime):
    time = input('Please, input the correct time\n')
    if (lastParaTime != -1):
        while (ConvertTimeToMins(time) - ConvertTimeToMins(lastParaTime) < 5) | (
                ConvertTimeToMins(time) - ConvertTimeToMins(lastParaTime) > 45):
            time = input('Please, input the correct time:\n')
    return time


def GetName():
    return input('Please, input the name of your lecture\nTo stop execution of program, enter ctrl+b\n')


def FillThatFile(path):
    oldPari, endTimeOfLastPara = DeserializeFile(path)
    PrintOutRozklad(oldPari)
    name = GetName()
    newPari=[]
    while name != '\02':
        start = GetTimeOfStart(endTimeOfLastPara)
        end = GetTimeOfEnd(start)
        endTimeOfLastPara=end
        newPari.append({'Name': name, 'startTime': start, 'endTime': end})
        name = GetName()
    with open(path, 'ab') as file:
         for para in newPari:
             dump(para,file)


