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
    if (exists(path)):
        with open(path, 'rb') as file:
            data = load(file)
            print('Note: last lecture ended at {yes}'.format(yes= data[-1]['endTime']))
        return pari, pari[-1]['endTime']
    else:
        return [], -1


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
    pari, lastPara = DeserializeFile(path)
    name = GetName()
    while name != '\02':
        start = GetTimeOfStart(lastPara)
        end = GetTimeOfEnd(start)
        lastPara=end
        pari.append({'Name:': name, 'startTime:': start, 'endTime': end})
        name = GetName()
    file = open(path, 'wb')
    dump(pari,file)
    file.close()