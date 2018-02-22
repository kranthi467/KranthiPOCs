#include<stdio.h>
#include<string.h>
int chek(int,char*);
int main()
{
	char str[1000];int c=0,i,j;
	scanf("%s",str);
	int n=strlen(str);
	for(i=n;i>1;i--)
	{int k=0;
		for(j=0;j<n-i+1;j++)
		{   k++;
			c=chek(i,str+j);
			if(c!=0)
			{   
				str[i+k]=0;
				printf("%s",str+j);
				i=0;
				j=n;
			}
		}
	}
}
int chek(int o,char *str)
{
	int n=o/2;
	for(int m=0;m<n;m++)
	{
		if(str[m]!=str[o-m])
		return 0;
	}
	return 1;
	
}
