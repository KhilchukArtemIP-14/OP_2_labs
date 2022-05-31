from StudentClass import *
from lecturerclass import *


def InitAcademics(studenti, vikladachi):
    for i in range(n):
        studenti.append(Student())
    for i in range(m):
        vikladachi.append(Vykladach())

def OutputRatings(studenti, vikladachi):
    print("Students\' grades:\n")
    for i in studenti:
        print(i.GetRating())
    print("Lecturers\' grades:\n")
    for i in vikladachi:
        print(i.GetRating())

def OutputUnderageWithDebt(studenti):
    underagesAndInDebted=[]
    print("Ages of students:")
    for i in studenti:
        print("{name}: {age}".format(name=i.GetName().ljust(12),age=str(i.GetAge()).ljust(12)))
        if(i.GetAge()<18):
            temp=i.GetGrades()
            for j in i.GetDisciplines():
                if(temp[j]<60):
                    underagesAndInDebted.append((i,j))
                    break
    print("And so, underage students with debt and one discipline that is indebted are:")
    if(len(underagesAndInDebted)==0):
        print("Fortunately, none")
    else:
        for stud,discp in underagesAndInDebted:
            print("{name}: {age}\n".format(name=stud.GetName().ljust(12), age=discp.ljust(12)))
        print("Their count-",len(underagesAndInDebted))


if __name__=="__main__":
    n=int(input("Please, input n (number of students)\n"))
    m=int(input("Plese, input m (number of lecturers)\n"))
    studenti=[]
    vikladachi=[]
    InitAcademics(studenti,vikladachi)
    OutputRatings(studenti,vikladachi)
    OutputUnderageWithDebt(studenti)
