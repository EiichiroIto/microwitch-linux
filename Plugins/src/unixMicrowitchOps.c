#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>
#include <dirent.h>
#include <unistd.h>
#include "microwitchOps.h"

#define BUF 512

int
MicrobitDevice(char *dst, int max)
{
  FILE	*fp;
  char	buf[BUF], *p, c, *volume;
  char	*cmdline = "mount";
  int count, len;

  if ((fp = popen(cmdline,"r")) == NULL) {
    return 0;
  }
  while(fgets(buf, BUF, fp) != NULL) {
    p = buf;
    count = 0;
    volume = NULL;
    while ((c = *p++) != '\0') {
      if (c == ' ') {
	if (count == 1) {
	  volume = p;
	} else if (count == 2) {
	  *--p = '\0';
	  break;
	}
	count ++;
      }
    }
    if (volume) {
      len = strlen(volume);
      if (len > 8) {
	if (strcmp(&volume[len-8], "MICROBIT") == 0) {
	  (void) pclose(fp);
	  strncpy(dst, volume, max);
	  return 1;
	}
      }
    }
  }
  (void) pclose(fp);
  return 0;
}

int
EnumerateComPorts(char *dst, int max)
{
  DIR *dir;
  struct dirent *dp;
  const char *devpath = "/dev/serial/by-id/";
  int size = 0, sz;

  dir = opendir(devpath);
  if (dir == NULL) {
    return 0;
  }
  while (1) {
    dp = readdir(dir);
    if (dp == NULL) {
      break;
    }
    if (*dp->d_name == '.') {
      continue;
    }
    sz = strlen(dp->d_name);
    memcpy(&dst[size], dp->d_name, sz);
    size += sz;
#ifdef MAIN
    dst[size++] = '\n';
#else
    dst[size++] = '\r';
#endif
  }
  closedir(dir);

  return size;
}

#ifdef MAIN
char buffer[1024];

void
dump(const char *buf, int size)
{
  int i, j;

  for (i = 0; i < (size + 15) / 16; i ++) {
    for (j = 0; j < 16; j ++) {
      int pos = i * 16 + j;
      if (pos < size) {
	printf("%02X ", (unsigned int) buf[pos]);
      }
    }
    printf("\n");
  }
}

int
main(int argc, char *argv[])
{
  int ret;

  memset(buffer, 0, sizeof buffer);
  ret = MicrobitDevice(buffer, sizeof buffer);
  printf("Microbit Drive:\n%d bytes\n'%s'\n", ret, buffer);

  memset(buffer, 0, sizeof buffer);
  ret = EnumerateComPorts(buffer, sizeof buffer);
  printf("ComPorts:\n%d bytes\n%s\n", ret, buffer);
  printf("Dumps:\n");
  dump(buffer, ret);
}

#endif /* MAIN */
