#include<stdio.h>
int linear(int key,int *a,int n)
{
int i=0;
while(i<n)
{
if(key==*(a+i))
   return i;
   i++;
}
return -1;
}
main()
{
int n,k,a[50],i,pos;
printf("Enter no of elements\n");
scanf("%d",&n);
printf("Enter elements to be searched\n");
for(i=0;i<n;i++)
scanf("%d",&a[i]);
printf("Enter The key to be searched\n");
scanf("%d",&k);
pos=linear(k,a,n);
printf("The position is %d",pos+1);
}



