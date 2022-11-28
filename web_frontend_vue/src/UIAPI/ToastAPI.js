import { useToast } from 'vue-toast-notification'

export function ShowToast(message, type = 'info') {
  const $toast = useToast()
  let instance = $toast.success(message, {
    type: type,
  })
}

/**
 * type : info,warning,error
 * position:top, bottom, top-right, bottom-right,top-left, bottom-left
 */
class toast_option {
  constructor(type, duration = 4, position = 'bottom-right') {
    this.type = type
    this.duration = duration
    this.position = position
  }
}

export var Toast = {
  Info(message, duration = 3, position = 'bottom-right') {
    const $toast = useToast()
    let instance = $toast.success(
      message,
      new toast_option('info', duration * 1000, position),
    )
  },
  Warning(message, duration = 3, position = 'bottom-right') {
    const $toast = useToast()
    let instance = $toast.success(
      message,
      new toast_option('warning', duration * 1000, position),
    )
  },
  Error(message, duration = 3, position = 'bottom-right') {
    const $toast = useToast()
    let instance = $toast.success(
      message,
      new toast_option('error', duration * 1000, position),
    )
  },
}
