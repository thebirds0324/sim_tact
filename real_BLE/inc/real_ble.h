#ifndef __real_ble_H__
#define __real_ble_H__

#include <dlog.h>
#include <Ecore.h>
#include <bluetooth.h>
#include <message_port.h>

#ifdef  LOG_TAG
#undef  LOG_TAG
#endif
#define LOG_TAG "real_ble"

int message_port_send_message_with_local_port (const char * remote_app_id, const char * remote_port,  bundle  * message, int local_port_id);
int message_port_register_local_port (const char *local_port, message_port_message_cb callback, void *user_data);

void __bt_adapter_le_scan_result_cb(int result, bt_adapter_le_device_scan_result_info_s *info, void *user_data);
int get_Area(int _stack[100], int _key, int _ind);
Eina_Bool my_timed_cb(void *data);

#endif /* __real_ble_H__ */

