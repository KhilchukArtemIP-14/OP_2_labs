directory=input('Please, input your directory for file\n')
name1=input('Please, input name for your file\n')
fulldirectory1=directory+'\\'+name1+".txt"
with open(fulldirectory1,'w') as file:
    print('Fill your file. To exit editing your file, enter ctrl+b\n')
    while(True):
        string=input()
        if(len(string)==1):
            if(ord(string)==2):
                break
        file.write(string+'\n')
with open(fulldirectory1,'r') as file:
    strings=file.readlines()
for i in range(len(strings)):
    strings[i]=strings[i].strip()
strings.sort(key=lambda x: len(x),reverse=True)
print('Array of lines, sorted by it\'s length')
print(strings)
name2=input('Please, input name for output file:\n')
fulldirectory2=directory+'\\'+name2+".txt"
with open(fulldirectory2,'w') as file:
    for i in range(len(strings)):
        file.write(str(len(strings[i]))+' '+strings[i]+'\n')
print('Execution ended successfully. Check your file')
print('Initial file:')
for i in range(len(strings)):
    print(strings[i])
with open(fulldirectory2, 'r') as file:
    strings = file.readlines()
print('Final file')
for i in range(len(strings)):
    print(strings[i].strip())

