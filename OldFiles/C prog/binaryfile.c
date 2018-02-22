#include<stdio.h>
struct student
{
int rno;
char name[20];
}st;
main()
{
FILE *fp;
int n,i;
fp=fopen("student.dat","w+b");
printf("Enter no of students\n");
scanf("%d",&n);
for(i=0;i<n;i++)
{
printf("Enter rno and name of %d student\n",i+1);
scanf("%d%s",&st.rno,st.name);
fwrite(&st,sizeof(struct student),1,fp);
}
rewind(fp);
for(i=1;i<=n;i++)
{
fread(&st,sizeof(struct student),1,fp);
printf("Roll no:%d\nName: %s\n",st.rno,st.name);
}
fclose(fp);
}
   
